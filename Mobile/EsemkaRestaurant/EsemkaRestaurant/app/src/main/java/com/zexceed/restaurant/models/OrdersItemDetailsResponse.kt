package com.zexceed.restaurant.models

data class OrdersItemDetailsResponse(
    val menu: OrdersItemDetailsMenuResponse,
    val quantity: Int,
    val subTotal: Int
)