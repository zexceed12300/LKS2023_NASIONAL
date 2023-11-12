package com.zexceed.restaurant

import android.animation.Animator
import android.animation.AnimatorSet
import android.animation.ValueAnimator
import android.content.Context
import android.graphics.Canvas
import android.graphics.Color
import android.graphics.Paint
import android.graphics.Paint.Style
import android.graphics.RectF
import android.util.AttributeSet
import android.view.View
import android.view.animation.LinearInterpolator

class LoadingView(context: Context, attrs: AttributeSet? = null ) : View(context, attrs) {

    val animatorSet = AnimatorSet()

    var startAngle = -270f
    var sweepAngle = 90f
    var sizeAngle = 180f
    private val startAnimator = ValueAnimator.ofFloat(startAngle, 360f)
    private val sweepAnimator = ValueAnimator.ofFloat(sweepAngle, 360f)

    private val backgroundPaint = Paint().apply {
        style = Style.STROKE
        color = Color.GRAY
        isAntiAlias = true
        strokeWidth = 60f
    }

    private  val innerPaint = Paint().apply {
        style = Style.STROKE
        color = Color.RED
        isAntiAlias = true
        strokeWidth = 60f
        strokeCap = Paint.Cap.ROUND
    }

    init {
        startAnimator.duration = 2000
        startAnimator.repeatCount = ValueAnimator.INFINITE
        startAnimator.interpolator = LinearInterpolator()
        startAnimator.addUpdateListener {
            startAngle = it.animatedValue as Float
            invalidate()
        }
        sweepAnimator.duration = 2000
        sweepAnimator.repeatCount = ValueAnimator.INFINITE
        sweepAnimator.interpolator = LinearInterpolator()
        sweepAnimator.addUpdateListener {
            sweepAngle = it.animatedValue as Float
            invalidate()
        }

        animatorSet.playSequentially(startAnimator, sweepAnimator)

        animatorSet.start()
    }

    override fun onDraw(canvas: Canvas) {
        super.onDraw(canvas)

        val rect = RectF(40f, 40f, width.toFloat() - 40f, height.toFloat() - 40f)

        canvas.drawArc(rect, 90f,360f, false, backgroundPaint)
        canvas.drawArc(rect, startAngle, sweepAngle, false, innerPaint)
    }
}