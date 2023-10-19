package com.zexceed.restaurant.models.staff

import com.zexceed.restaurant.models.OrdersItemResponse

data class TableDetailsResponseStaff(
    val tableId: String,
    val number: Int,
    val code: String,
    val closedAt: String?,
    val orders: List<OrdersItemResponse>,
)
