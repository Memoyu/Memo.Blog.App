<script setup lang="ts">
import api from "@/services/api";
import { UserPageItem } from "@/types/interfaces";
import dayjs from "dayjs";

const users = ref<UserPageItem[]>([]);
const loading = ref(false);
const finished = ref(true);

const search = ref("");
const page = ref(1);
const pageSize = 15;

onMounted(() => {
  // 获取友链列表
  getUsers("");
});
function onSearch(text: string) {
  getUsers(text);
}
function getUsers(text: string) {
  api
    .userPage({
      username: text,
      nickname: text,
      page: page.value,
      size: pageSize,
    })
    .then((res) => {
      users.value = res.items;
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
      <list-card class="user-item" v-for="item in users" :key="item.userId">
        <div class="flex">
          <div class="shrink-0 flex items-center">
            <van-image round cover width="80" height="80" :src="item.avatar" />
          </div>
          <div class="ml-30 flex flex-col">
            <div class="ur-name-box">
              <div class="ur-nickname">{{ item.nickname }}</div>
              <div class="ur-username">({{ item.username }})</div>
            </div>
            <div class="ur-role-box">
              <van-tag v-for="role in item.roles" :key="role.name">
                {{ role.name }}
              </van-tag>
            </div>
            <div class="ur-info-box">
              <div class="ur-info-item">
                <div class="i-carbon:email" />
                <van-text-ellipsis class="ur-email" :content="item.email" />
              </div>
              <div class="ur-info-item">
                <div class="i-carbon:phone" />
                <van-text-ellipsis
                  class="ur-phone-number"
                  :content="item.phoneNumber"
                />
              </div>
            </div>
          </div>
        </div>
        <div class="ur-bottom-box">
          {{ dayjs(item.createTime).format("YYYY-MM-DD HH:mm") }}
        </div>
      </list-card>
    </van-list>
  </div>
</template>

<style lang="less" scoped>
.user-item {
  background: var(--van-background-2);
}
.ur-name-box {
  display: flex;
  align-items: baseline;

  .ur-nickname {
    font-weight: 700;
  }
  .ur-username {
    font-size: 12px;
  }
}

.ur-role-box {
  margin-top: 5px;
  --at-apply: flex space-x-20;
}
.ur-info-box {
  margin-top: 3px;
  .ur-info-item {
    font-size: var(--van-font-size-md);

    --at-apply: flex items-center space-x-5;
  }
}

.ur-bottom-box {
  display: flex;
  justify-content: flex-end;
  font-size: var(--van-font-size-md);
  color: var(--van-text-color-2);
}
</style>

<route lang="json5">
{
  name: "User",
  meta: {
    title: "用户",
  },
}
</route>
