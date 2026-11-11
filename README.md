# Restaurant POS: Cashier + Kitchen Display

A small two-application order system modeled on a real restaurant workflow:
a **cashier app** takes an order and sends it over TCP to a **kitchen display**,
where it appears as a live ticket.

| Part | Language / UI | Role |
| --- | --- | --- |
| `CashierPOS/` | C# (.NET 8), Windows Forms | TCP client: sends new orders |
| `KitchenDisplay/` | Java, JavaFX | TCP server: receives orders and shows tickets |

## How it works

```
Cashier POS (C#)  --TCP :8080-->  Kitchen Display (Java / JavaFX)
  NEW_ORDER|<id>|<items>\n          parses message -> Order -> ticket on screen
```

**Protocol:** one text line per order, fields separated by `|`:

```
NEW_ORDER|3|2x Burger, 1x Fries
```

The server accepts a message only if it has exactly three fields and the first is `NEW_ORDER`.

## Design notes

- The server socket runs on a background **daemon thread**, so it never blocks the UI.
- Incoming orders update the board through `Platform.runLater`, because JavaFX UI changes must happen on the UI thread.
- The Java side is split into `Order` (model), `KitchenController` (UI logic), `KitchenServer` (networking) and `MainApp` (startup).
- If the cashier cannot reach the kitchen, it shows an error and rolls the order number back so no number is lost.

## Run it

1. **Start the kitchen display first** (it listens on port 8080). With JDK 17+ and the
   [JavaFX SDK](https://openjfx.io/) downloaded, from the `KitchenDisplay` folder:

   ```
   javac --module-path <path-to-javafx>/lib --add-modules javafx.controls -d out src/main/java/com/example/*.java
   java  --module-path <path-to-javafx>/lib --add-modules javafx.controls -cp out com.example.MainApp
   ```

2. **Start the cashier** (Windows, .NET 8 SDK): from the `CashierPOS` folder run `dotnet run`,
   or open `TcpProiect2.csproj` in Visual Studio.
3. Type items such as `2x Burger, 1x Fries`, click **Send to Kitchen**, and the ticket appears in the kitchen window.

## Possible improvements

- Let the kitchen mark tickets as done and send a status back to the cashier.
- Make the server address configurable instead of fixed to `127.0.0.1:8080`.
- Persist orders so they survive a restart.
