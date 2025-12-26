<script setup lang="ts">
import api from "@/services/api";
import { OpenSourceListItem } from "@/types/interfaces/open-source";
import dayjs from "dayjs";

const sources = ref<OpenSourceListItem[]>([]);
const loading = ref(false);
const finished = ref(true);

const search = ref("");

onMounted(() => {
  // 获取开源列表
  getOpenSources("");
});
function onSearch(text: string) {
  getOpenSources(text);
}
function getOpenSources(text: string) {
  api
    .openSourceList({
      title: text,
      description: text,
    })
    .then((res) => {
      sources.value = res;
    });
}
</script>

<template>
  <van-search
    v-model="search"
    placeholder="请输入搜索关键词"
    @search="onSearch"
  />
  <div>
    <van-list v-model:loading="loading" :finished="finished">
      <list-card class="os-item" v-for="item in sources" :key="item.projectId">
        <div class="flex">
          <div class="shrink-0 flex items-center">
            <van-image
              fit="cover"
              width="140"
              height="80"
              :src="item.imageUrl"
            />
          </div>
          <div class="ml-30 flex flex-col">
            <van-text-ellipsis class="os-title" :content="item.title" />
            <van-text-ellipsis
              class="os-desc"
              rows="2"
              :content="item.description"
            />
          </div>
        </div>
        <div class="os-bottom-box os-gray-font">
          <div class="flex space-x-40">
            <div class="info-item">
              <div class="i-carbon:star" />
              <span>{{ item.star }}</span>
            </div>
            <div class="info-item">
              <div class="i-carbon:fork" />
              <span>{{ item.fork }}</span>
            </div>
          </div>
          <div class="os-date-box">
            <div class="i-carbon:time" />
            <div>
              {{ dayjs(item.createTime).format("YYYY-MM-DD HH:mm") }}
            </div>
          </div>
        </div>
      </list-card>
    </van-list>
  </div>
</template>

<style lang="less" scoped>
.os-item {
  background: var(--van-background-2);
}

.os-title {
  font-weight: 700;
  margin-bottom: 10px;
}
.os-desc {
  margin-top: 5px;
  font-size: var(--van-font-size-md);
  color: var(--van-text-color-2);
}

.os-bottom-box {
  font-size: var(--van-font-size-md);
  --at-apply: mt-5 flex justify-between items-center;
  .info-item {
    --at-apply: flex items-center space-x-5;
  }
}

.os-gray-font {
  font-size: var(--van-font-size-md);
  color: var(--van-text-color-2);
}

.os-date-box {
  --at-apply: flex items-center space-x-5;
}
</style>

<route lang="json5">
{
  name: "OpenSource",
  meta: {
    title: "开源项目",
  },
}
</route>
