<script setup lang="ts">
import dayjs from "dayjs";
import api from "@/services/api";
import { FriendPageItem } from "@/types/interfaces/friend";

const friends = ref<FriendPageItem[]>([]);
const loading = ref(false);
const finished = ref(true);

const search = ref("");
const page = ref(1);
const pageSize = 15;

onMounted(() => {
  // 获取友链列表
  getFriends("");
});
function onSearch(text: string) {
  getFriends(text);
}
function getFriends(text: string) {
  api
    .friendPage({
      nickname: text,
      description: text,
      site: text,
      page: page.value,
      size: pageSize,
    })
    .then((res) => {
      friends.value = res.items;
    });
}
</script>

<template>
  <nav-bar />
  <van-search
    v-model="search"
    placeholder="请输入搜索关键词"
    @search="onSearch"
  />
  <div>
    <van-list v-model:loading="loading" :finished="finished">
      <list-card
        class="friend-item"
        v-for="item in friends"
        :key="item.friendId"
      >
        <div class="flex">
          <div class="shrink-0 flex items-center">
            <van-image round cover width="80" height="80" :src="item.avatar" />
          </div>
          <div class="ml-30 flex flex-col">
            <div class="fr-nickname">{{ item.nickname }}</div>
            <van-text-ellipsis class="fr-site" :content="item.site" />
            <van-text-ellipsis class="fr-desc" :content="item.description" />
          </div>
        </div>
        <div class="fr-bottom-box">
          <div class="flex space-x-40">
            <div class="info-item">
              <div class="i-carbon-view" />
              <div>{{ item.views }}</div>
            </div>
            <div class="info-item">
              <div>公开</div>
              <div v-if="item.showable" class="fr-showable-dot-true" />
              <div v-else class="fr-showable-dot-false" />
            </div>
          </div>
          <div>
            {{ dayjs(item.createTime).format("YYYY-MM-DD HH:mm") }}
          </div>
        </div>
      </list-card>
    </van-list>
  </div>
</template>

<style lang="less" scoped>
.friend-item {
  background: var(--van-background-2);
}
.fr-nickname {
  font-weight: 700;
  margin-bottom: 10px;
}
.fr-site {
  font-size: var(--van-font-size-md);
  color: var(--van-text-color-2);
}
.fr-desc {
  font-size: var(--van-font-size-md);
  color: var(--van-text-color-2);
}
.fr-bottom-box {
  font-size: var(--van-font-size-md);
  --at-apply: mt-5 flex justify-between items-center;
  .info-item {
    --at-apply: flex items-center space-x-5;
  }
}

.fr-showable-dot {
  --at-apply: inline-block w-10 h-10 rounded-full;
}
.fr-showable-dot-true {
  &:extend(.fr-showable-dot);
  --at-apply: bg-green-500;
}
.fr-showable-dot-false {
  &:extend(.fr-showable-dot);
  --at-apply: bg-gray-400;
}
</style>

<route lang="json5">
{
  name: "FriendlyLink",
  meta: {
    title: "友链",
  },
}
</route>
