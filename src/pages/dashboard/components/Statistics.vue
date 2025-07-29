<script setup lang="ts">
import * as echarts from "echarts";

const lineOption = ref({
  color: ["rgba(166,127,221)"],
  tooltip: {
    trigger: "axis",
  },
  xAxis: [
    {
      type: "category",
      boundaryGap: false,
      show: false,
    },
  ],
  yAxis: [
    {
      type: "value",
      show: false,
    },
  ],
  series: [
    {
      type: "line",
      smooth: true,
      showSymbol: false,
      areaStyle: {
        opacity: 0.8,
        color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [
          {
            offset: 0,
            color: "rgba(166,127,221)",
          },
          {
            offset: 1,
            color: "rgba(226, 209, 224)",
          },
        ]),
      },
      emphasis: {
        focus: "series",
      },
      data: [
        ["2025-07-23", "5"],
        ["2025-07-24", "1"],
        ["2025-07-25", "1"],
        ["2025-07-26", "3"],
        ["2025-07-27", "1"],
        ["2025-07-28", "9"],
        ["2025-07-29", "2"],
      ],
    },
  ],
});
</script>

<template>
  <van-grid :border="false" :column-num="2">
    <van-grid-item>
      <div class="stat-item space-y-3">
        <div>
          <p class="stat-num">120</p>
          <p class="stat-title">文章总数</p>
        </div>
        <div class="flex justify-between">
          <div class="flex items-end space-x-3">
            <p class="stat-title">动态</p>
            <p class="stat-num">12</p>
          </div>
          <div class="flex items-end space-x-3">
            <p class="stat-title">友链</p>
            <p class="stat-num">12</p>
          </div>
        </div>
      </div>
    </van-grid-item>
    <van-grid-item>
      <div class="stat-item">
        <div>
          <p class="stat-num">170</p>
          <p class="stat-title">浏览总数</p>
        </div>
        <div>
          <Chart :option="lineOption" :style="{ height: '70px' }" />
        </div>
      </div>
    </van-grid-item>
    <van-grid-item>
      <div class="stat-item">
        <div>
          <p class="stat-num">150</p>
          <p class="stat-title">访问总数</p>
        </div>
        <div>
          <Chart :option="lineOption" :style="{ height: '70px' }" />
        </div>
      </div>
    </van-grid-item>
    <van-grid-item>
      <div class="stat-item">
        <div>
          <p class="stat-num">130</p>
          <p class="stat-title">评论总数</p>
        </div>
        <div>
          <Chart :option="lineOption" :style="{ height: '70px' }" />
        </div>
      </div>
    </van-grid-item>
  </van-grid>
</template>

<style lang="less" scoped>
:deep(.van-grid-item__content) {
  border-radius: 10px;
}
:deep(.van-grid-item) {
  padding: 5px;
}
.stat-item {
  height: 130px;
  width: 100%;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  padding: 6px 8px;

  .stat-title {
    color: var(--van-gray-7);
  }
  .stat-num {
    font-size: 20px;
    line-height: 28px;
    font-weight: 700;
  }
}
</style>
