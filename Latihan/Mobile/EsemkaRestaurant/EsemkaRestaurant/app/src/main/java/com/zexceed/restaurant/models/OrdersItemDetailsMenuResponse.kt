package com.zexceed.restaurant.models

data class OrdersItemDetailsMenuResponse(
    val category: String,
    val description: String,
    val menuId: String,
    val name: String,
    val price: Int
)