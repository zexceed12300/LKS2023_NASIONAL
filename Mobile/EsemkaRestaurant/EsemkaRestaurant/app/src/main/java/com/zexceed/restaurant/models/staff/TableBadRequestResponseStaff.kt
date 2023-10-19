package com.zexceed.restaurant.models.staff

data class TableBadRequestResponseStaff(
    val type: String,
    val title: String,
    val status: String,
    val traceId: String,
    val errors: TableBadRequestErrorsResponseStaff,
)
