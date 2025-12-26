<script setup lang="ts">
import router from "@/router";
import { useUserStore, useAuthTokenStore } from "@/stores";

const authTokenStore = useAuthTokenStore();
const isLogin = computed(() => authTokenStore.isLogin());

const userStore = useUserStore();
const userInfo = computed(() => userStore.userInfo);

function login() {
  if (isLogin) {
    router.push({ name: "ProfileEdit" });
    return;
  }

  router.push({ name: "Login", query: { redirect: "Profile" } });
}

function getUserNickname() {
  if (!isLogin) return "请登录";

  return userInfo.value.nickname;
}
</script>
<template>
  <div>
    <VanCellGroup :inset="true">
      <van-cell center is-link @click="login">
        <template #title>
          <div class="flex">
            <van-image
              :src="userInfo.avatar"
              round
              class="shrink-1 h-70 w-70"
            />
            <div class="flex flex-col justify-center ml-15">
              <div class="nickname">{{ getUserNickname() }}</div>
              <div class="flex space-x-20">
                <van-tag v-for="item in userInfo.roles" :key="item.name">
                  {{ item.name }}
                </van-tag>
              </div>
            </div>
          </div>
        </template>
      </van-cell>
    </VanCellGroup>
    <commit />
    <function-grid />
  </div>
</template>

<style lang="less" scoped>
.nickname {
  font-size: var(--van-line-height-md);
  font-weight: 700;
  margin-bottom: 8px;
}
</style>

<route lang="json5">
{
  name: "Profile",
  meta: {
    title: "个人",
  },
}
</route>
