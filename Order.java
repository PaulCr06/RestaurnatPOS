package com.example;

public class Order {
    private String orderId;
    private String items;

    public Order(String orderId, String items) {
        this.orderId = orderId;
        this.items = items;
    }

    public String getOrderId() { return orderId; }
    public String getItems() { return items; }
}
