package com.example;

import javafx.application.Platform;
import javafx.scene.layout.FlowPane;
import javafx.scene.layout.VBox;
import javafx.scene.control.Label;
import javafx.geometry.Insets;

public class KitchenController {
    private FlowPane ticketBoard;

    public KitchenController(FlowPane ticketBoard) {
        this.ticketBoard = ticketBoard;
        this.ticketBoard.setHgap(10);
        this.ticketBoard.setVgap(10);
        this.ticketBoard.setPadding(new Insets(15));
    }

    public void addOrderTicket(Order newOrder) {
        Platform.runLater(() -> {
            VBox ticket = new VBox(5);
            ticket.setStyle("-fx-border-color: black; -fx-background-color: lightyellow; -fx-padding: 10;");
            
            Label lblId = new Label("Order #" + newOrder.getOrderId());
            lblId.setStyle("-fx-font-weight: bold; -fx-font-size: 16;");
            
            Label lblItems = new Label(newOrder.getItems());
            lblItems.setWrapText(true);
            
            ticket.getChildren().addAll(lblId, lblItems);
            ticketBoard.getChildren().add(ticket);
        });
    }
}
