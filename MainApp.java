package com.example;

import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.layout.FlowPane;
import javafx.stage.Stage;

public class MainApp extends Application {
    @Override
    public void start(Stage primaryStage) {
        FlowPane ticketBoard = new FlowPane();
        KitchenController controller = new KitchenController(ticketBoard);
        
        Thread serverThread = new Thread(new KitchenServer(controller));
        serverThread.setDaemon(true); 
        serverThread.start();

        Scene scene = new Scene(ticketBoard, 800, 600);
        primaryStage.setTitle("Kitchen Display System");
        primaryStage.setScene(scene);
        primaryStage.show();
    }

    public static void main(String[] args) {
        launch(args);
    }
}
