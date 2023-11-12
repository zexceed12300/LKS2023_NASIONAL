package com.zexceed.restaurant

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import androidx.recyclerview.widget.LinearLayoutManager
import com.zexceed.restaurant.adapter.OrdersAdapter
import com.zexceed.restaurant.apiservices.ApiServices
import com.zexceed.restaurant.databinding.FragmentOrdersBinding
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext

class OrdersFragment : Fragment() {

    private var _binding: FragmentOrdersBinding? = null

    // This property is only valid between onCreateView and
    // onDestroyView.
    private val binding get() = _binding!!

    private lateinit var mAdapter: OrdersAdapter

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = FragmentOrdersBinding.inflate(inflater, container, false)
        val root: View = binding.root
        return root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        mAdapter = OrdersAdapter()

        queryOrders()

        binding.apply {
            refreshOrders.setOnRefreshListener {
                queryOrders()
                refreshOrders.isRefreshing = false
            }
        }
    }

    private fun queryOrders() {
        binding.apply {
            val coroutineScope = CoroutineScope(Dispatchers.IO)
            coroutineScope.launch {
                val req = ApiServices(requireActivity())
                val res = req.getOrders()
                mAdapter.submitList(res)
                withContext(Dispatchers.Main) {
                    rvOrders.apply {
                        adapter = mAdapter
                        layoutManager = LinearLayoutManager(requireActivity())
                        setHasFixedSize(true)
                    }
                }
            }
        }
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }
}