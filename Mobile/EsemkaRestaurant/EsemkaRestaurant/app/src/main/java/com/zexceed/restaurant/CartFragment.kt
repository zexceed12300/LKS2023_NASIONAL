package com.zexceed.restaurant

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.recyclerview.widget.LinearLayoutManager
import com.zexceed.restaurant.adapter.CartAdapter
import com.zexceed.restaurant.apiservices.ApiServices
import com.zexceed.restaurant.databinding.FragmentCartBinding
import com.zexceed.restaurant.models.OrderRequest
import com.zexceed.restaurant.preferences.CartPreferences
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import java.net.HttpURLConnection

class CartFragment : Fragment() {

    private var _binding: FragmentCartBinding? = null

    // This property is only valid between onCreateView and
    // onDestroyView.
    private val binding get() = _binding!!

    private lateinit var mAdapter: CartAdapter

    private lateinit var preferences: CartPreferences

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = FragmentCartBinding.inflate(inflater, container, false)
        val root: View = binding.root
        return root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        preferences = CartPreferences(requireActivity())

        binding.apply {

            tvTotalPrice.text = "Rp. "+preferences.getTotalPrice().toString()

            mAdapter = CartAdapter(
                onClickQtyDecrement = { data ->
                    if (data.qty > 0)
                        data.qty -= 1
                    preferences.updateCart(
                        menuId = data?.menuId.toString(),
                        menuName = data?.name.toString(),
                        price = data.price,
                        qty = data.qty,
                    )
                    tvTotalPrice.text = "Rp. "+preferences.getTotalPrice().toString()
                },
                onClickQtyIncrement = { data ->
                    data.qty += 1
                    preferences.updateCart(
                        menuId = data?.menuId.toString(),
                        menuName = data?.name.toString(),
                        price = data.price,
                        qty = data.qty,
                    )
                    tvTotalPrice.text = "Rp. "+preferences.getTotalPrice().toString()
                },
                onClickRemove = { data ->
                    preferences.deleteCart(data.menuId)
                    submitList()
                    tvTotalPrice.text = "Rp. "+preferences.getTotalPrice().toString()
                }
            )
            submitList()

            btnOrder.setOnClickListener {

                val orderData = arrayListOf<OrderRequest>()
                preferences.getCartList().map {
                    orderData.add(
                        OrderRequest(
                            menuId = it.menuId,
                            quantity = it.qty
                        )
                    )
                }

                val corotineScope = CoroutineScope(Dispatchers.IO)

                corotineScope.launch {
                    val req = ApiServices(requireActivity())
                    val res = req.storeOrder(orderData)
                    requireActivity().runOnUiThread {
                        if (req.responseCode == HttpURLConnection.HTTP_OK) {
                            Toast.makeText(requireActivity(), "Order Success!", Toast.LENGTH_SHORT).show()
                        } else {
                            Toast.makeText(requireActivity(), "Order failed! ${req.responseCode}", Toast.LENGTH_SHORT).show()
                        }
                    }
                }
            }
        }
    }

    private fun submitList() {
        binding.apply {
            mAdapter.submitList(preferences.getCartList())
            rvCart.apply {
                adapter = mAdapter
                layoutManager = LinearLayoutManager(requireActivity())
                setHasFixedSize(true)
            }
        }
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }
}