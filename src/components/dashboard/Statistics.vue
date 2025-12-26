<script setup lang="ts">
import * as echarts from "echarts";
import api from "@/services/api";
import { DashboardStatistics } from "@/types/interfaces/dashboard";
import { cloneDeep } from "lodash-es";

const lineOption = {
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
      data: [],
    },
  ],
};

const stat = ref<DashboardStatistics>();
const pageVisitorLineOption = ref();
const uniqueVisitorLineOption = ref();
const commentLineOption = ref();

onMounted(() => {
  api.statistics().then((res) => {
    stat.value = res;
    // 浏览
    pageVisitorLineOption.value = cloneDeep(lineOption);
    pageVisitorLineOption.value.series[0].data =
      res.pageVisitor.weekPageVisitors.map((u) => [u.name, u.value]);
    // 访问
    uniqueVisitorLineOption.value = cloneDeep(lineOption);
    uniqueVisitorLineOption.value.series[0].data =
      res.uniqueVisitor.weekUniqueVisitors.map((u) => [u.name, u.value]);
    // 评论
    commentLineOption.value = cloneDeep(lineOption);
    commentLineOption.value.series[0].data = res.comment.weekComments.map(
      (u) => [u.name, u.value],
    );
  });
});
</script>

<template>
  <van-grid :border="false" :column-num="2">
    <van-grid-item>
      <div class="stat-item space-y-3">
        <div>
          <p class="stat-num">{{ stat?.summary.articles }}</p>
          <p class="stat-title">文章总数</p>
        </div>
        <div class="flex justify-between">
          <div class="flex items-end space-x-3">
            <p class="stat-title">动态</p>
            <p class="stat-num">{{ stat?.summary.moments }}</p>
          </div>
          <div class="flex items-end space-x-3">
            <p class="stat-title">友链</p>
            <p class="stat-num">{{ stat?.summary.friends }}</p>
          </div>
        </div>
      </div>
    </van-grid-item>
    <van-grid-item>
      <div class="stat-item">
        <div>
          <p class="stat-num">{{ stat?.pageVisitor.pageVisitors }}</p>
          <p class="stat-title">浏览总数</p>
        </div>
        <div>
          <Chart :option="pageVisitorLineOption" :style="{ height: '70px' }" />
        </div>
      </div>
    </van-grid-item>
    <van-grid-item>
      <div class="stat-item">
        <div>
          <p class="stat-num">{{ stat?.uniqueVisitor.uniqueVisitors }}</p>
          <p class="stat-title">访问总数</p>
        </div>
        <div>
          <Chart
            :option="uniqueVisitorLineOption"
            :style="{ height: '70px' }"
          />
        </div>
      </div>
    </van-grid-item>
    <van-grid-item>
      <div class="stat-item">
        <div>
          <p class="stat-num">{{ stat?.comment.comments }}</p>
          <p class="stat-title">评论总数</p>
        </div>
        <div>
          <Chart :option="commentLineOption" :style="{ height: '70px' }" />
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
