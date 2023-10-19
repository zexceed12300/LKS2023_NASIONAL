package com.zexceed.restaurant.models

data class OrdersItemResponse(
    val createdAt: String,
    val orderDetails: List<OrdersItemDetailsResponse>,
    val orderId: String,
    val status: String
)