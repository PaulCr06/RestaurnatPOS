package com.example;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.ServerSocket;
import java.net.Socket;

public class KitchenServer implements Runnable {
    private KitchenController controller;

    public KitchenServer(KitchenController controller) {
        this.controller = controller;
    }

    @Override
    public void run() {
        try (ServerSocket serverSocket = new ServerSocket(8080)) {
            while (true) {
                Socket clientSocket = serverSocket.accept();
                BufferedReader in = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
                String orderData = in.readLine();
                
                if (orderData != null) {
                    String[] parts = orderData.split("\\|");
                    if (parts.length == 3 && parts[0].equals("NEW_ORDER")) {
                        Order order = new Order(parts[1], parts[2]);
                        controller.addOrderTicket(order);
                    }
                }
                clientSocket.close();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
