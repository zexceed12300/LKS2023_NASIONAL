package com.zexceed.restaurant.models

data class Cart(
    val menuId: String,
    val name: String,
    val price: Int,
    var qty: Int,
)