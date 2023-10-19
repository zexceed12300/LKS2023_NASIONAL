package com.zexceed.restaurant.adapter

import android.os.Bundle
import android.util.Log
import androidx.fragment.app.Fragment
import androidx.fragment.app.FragmentManager
import androidx.lifecycle.Lifecycle
import androidx.viewpager2.adapter.FragmentStateAdapter
import com.zexceed.restaurant.MenuPagerFragment

class MenuPagerAdapter(fragmentManager: FragmentManager, lifecycle: Lifecycle) : FragmentStateAdapter(fragmentManager, lifecycle) {
    override fun getItemCount(): Int {
        return 9
    }

    override fun createFragment(position: Int): Fragment {
        val fragment: Fragment = MenuPagerFragment()
//        when(position) {
//            0 -> {
//                fragment.arguments = Bundle().apply {
//                    putString(MENU_TAB_CATEGORY, "Ayam")
//                }
//            }
//            1 -> {
//                fragment.arguments = Bundle().apply {
//                    putString(MENU_TAB_CATEGORY, "Cemilan")
//                }
//            }
//        }
        fragment.arguments = Bundle().apply {
            putInt(MENU_TAB_CATEGORY, position)
            //Log.d("Menu Pager::::", "createFragment: Ayammmmm")
        }

        return fragment
    }

    companion object {
        const val MENU_TAB_CATEGORY = "category"
    }

}