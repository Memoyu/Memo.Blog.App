<script setup lang="ts">
import api from "@/services/api";
import { SystemLogLevel, SystemLogPageItem } from "@/types/interfaces";
import dayjs from "dayjs";

const page = ref(1);
const totalItme = ref(0);
const pageSize = 15;

const dateValue = ref(0);
const dateOption = ref([
  { text: "全部", value: 0 },
  { text: "近7天", value: 1 },
  { text: "近30天", value: 2 },
  { text: "近90天", value: 3 },
  { text: "自定义", value: 4 },
]);
const showPicker = ref(false);
const selectedDateRange = ref<[][]>([[], []]);
const minDate = new Date(2020, 0, 1);
const maxDate = new Date(2025, 5, 1);

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

function onDateChange(val: number) {
  console.log(val);
  if (val === 4) {
    showPicker.value = true;
  } else {
    dateOption.value[4].text = "自定义";
  }
}

function onDatePickerBtnClick(e: any, isCancel: boolean) {
  showPicker.value = false;
  // console.log(e);
  if (isCancel) return;
  var { startDate } = e[0];
  var { endDate } = e[1];

  selectedDateRange.value = [startDate, endDate];
  // console.log("选中", selectedDateRange);
  dateOption.value[4].text = `${dayjs(startDate).format(
    "YYYY-MM-DD",
  )} 至 ${dayjs(endDate).format("YYYY-MM-DD")}`;
}

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
      @change="onDateChange"
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
    <list-card v-for="item in logs" :key="item.id">
      <div class="sys-log-item">
        <div class="flex justify-between">
          <div class="sys-log-level">{{ SystemLogLevel[item.level] }}</div>
          <div>{{ dayjs(item.time).format("YYYY-MM-DD HH:mm") }}</div>
        </div>
        <div class="flex">
          <div>请求：</div>
          <van-text-ellipsis class="sys-log-text" :content="item.requestPath" />
        </div>
        <div>
          <div>日志：</div>
          <van-text-ellipsis
            class="sys-log-text"
            rows="3"
            :content="item.message"
            expand-text="展开"
            collapse-text="收起"
          />
        </div>
        <div v-if="item.exMessage.length > 0">
          <div>异常：</div>
          <van-text-ellipsis
            class="sys-log-text"
            rows="3"
            :content="item.exMessage"
            expand-text="展开"
            collapse-text="收起"
          />
        </div>
      </div>
    </list-card>
  </van-list>
  <van-pagination
    v-if="totalItme > 0"
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
  <van-popup v-model:show="showPicker" round position="bottom">
    <van-picker-group
      title="预约日期"
      :tabs="['开始日期', '结束日期']"
      @confirm="(e) => onDatePickerBtnClick(e, false)"
      @cancel="(e) => onDatePickerBtnClick(e, true)"
    >
      <van-date-picker
        v-model="selectedDateRange[0]"
        :min-date="minDate"
        :max-date="maxDate"
      />
      <van-date-picker
        v-model="selectedDateRange[1]"
        :min-date="minDate"
        :max-date="maxDate"
      />
    </van-picker-group>
  </van-popup>
</template>

<style lang="less" scoped>
.sys-log-item {
  padding: 10px;
}

.sys-log-level {
  font-weight: bold;
}

.sys-log-text {
  font-size: var(--van-font-size-md);
  color: var(--van-text-color-2);
}
</style>
