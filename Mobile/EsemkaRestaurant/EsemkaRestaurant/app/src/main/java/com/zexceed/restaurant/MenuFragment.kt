package com.zexceed.restaurant

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.annotation.StringRes
import androidx.fragment.app.Fragment
import androidx.viewpager2.widget.ViewPager2
import com.google.android.material.tabs.TabLayout
import com.google.android.material.tabs.TabLayoutMediator
import com.zexceed.restaurant.adapter.MenuPagerAdapter
import com.zexceed.restaurant.databinding.FragmentMenuBinding

class MenuFragment : Fragment() {

    private var _binding: FragmentMenuBinding? = null

    // This property is only valid between onCreateView and
    // onDestroyView.
    private val binding get() = _binding!!

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        _binding = FragmentMenuBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val pagerAdapter = MenuPagerAdapter(childFragmentManager, lifecycle)
        val viewPager: ViewPager2 = binding.pager
        val tabs: TabLayout = binding.tabLayout
        viewPager.adapter = pagerAdapter
        TabLayoutMediator(tabs, viewPager) { tab, position ->
            tab.text = resources.getString(TAB_TITLES[position])
        }.attach()
    }

    companion object {
        @StringRes
        private val TAB_TITLES = intArrayOf(
            R.string.menu_1,
            R.string.menu_2,
            R.string.menu_3,
            R.string.menu_4,
            R.string.menu_5,
            R.string.menu_6,
            R.string.menu_7,
            R.string.menu_8,
            R.string.menu_9,
        )
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }
}