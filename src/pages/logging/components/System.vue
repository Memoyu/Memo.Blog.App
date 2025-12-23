<script setup lang="ts">
import api from "@/services/api";
import { SystemLogLevel, SystemLogPageItem } from "@/types/interfaces";
import dayjs from "dayjs";
import { showToast } from "vant";

const page = ref(1);
const totalItme = ref(1);
const pageSize = 15;

const dateValue = ref(0);
const dateOption = [
  { text: "全部", value: 0 },
  { text: "近7天", value: 1 },
  { text: "近30天", value: 2 },
  { text: "近90天", value: 3 },
  { text: "自定义", value: 4 },
];
const value = ref(0);
const option = [
  { text: "全部", value: 0 },
  { text: "Debug", value: 1 },
  { text: "Info", value: 2 },
  { text: "Warning", value: 3 },
  { text: "Error", value: 4 },
  { text: "Fatal", value: 5 },
];

const logs = ref<SystemLogPageItem[]>([]);

const search = ref("");

onMounted(() => {
  getLogs();
});

function getLogs() {
  api
    .systemLogPage({
      page: page.value,
      size: pageSize,
    })
    .then((res) => {
      logs.value = res.items;
      totalItme.value = res.total;
    });
}

function onPaginationChange(e: any) {
  console.log(e);
}

function onSearch(text: string) {}
</script>

<template>
  <van-search
    v-model="search"
    placeholder="请输入搜索关键词"
    @search="onSearch"
  />
  <van-dropdown-menu>
    <van-dropdown-item
      v-model="dateValue"
      :activated="dateValue !== 0"
      :options="dateOption"
      light
    />
    <van-dropdown-item
      v-model="value"
      :options="option"
      :activated="value !== 0"
      light
    />
    <!-- <van-dropdown-item
      v-model="showBrand"
      :title="
        selectedBrand.length
          ? selectedBrand.map((_) => _.label).join('、')
          : '品牌'
      "
      :activated="!!selectedBrand.length"
      just-trigger="select"
      light
    />
    <van-dropdown-item v-model="switch1" title="包邮" light just-trigger />
    <van-dropdown-item v-model="switch2" title="团购" light just-trigger />
    <van-dropdown-item
      title="VanFilter 筛选"
      light
      just-trigger
      @click="onFilter"
    /> -->
  </van-dropdown-menu>
  <van-list>
    <list-card class="sys-log-item" v-for="item in logs" :key="item.id">
      <div>
        <div class="flex justify-between">
          <div>{{ SystemLogLevel[item.level] }}</div>
          <div>{{ dayjs(item.time).format("YYYY-MM-DD HH:mm") }}</div>
        </div>
        <div>请求路径： {{ item.requestPath }}</div>
        <div>
          <div>内容</div>
          <van-text-ellipsis
            rows="3"
            :content="item.message"
            expand-text="展开"
            collapse-text="收起"
          />
        </div>
      </div>
    </list-card>
  </van-list>
  <van-pagination
    v-model="page"
    :total-items="totalItme"
    :show-page-size="5"
    force-ellipses
    @change="onPaginationChange"
  >
    <template #prev-text>
      <van-icon name="arrow-left" />
    </template>
    <template #next-text>
      <van-icon name="arrow" />
    </template>
    <template #page="{ text }">{{ text }}</template>
  </van-pagination>
</template>

<style lang="less" scoped>
.sys-log-item {
}
</style>
