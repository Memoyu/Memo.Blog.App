<script setup lang="ts">
import api from "@/services/api";
import { UserInfo } from "@/types/interfaces";

const userInfo = ref<UserInfo>({} as UserInfo);

onMounted(() => {
  api.getUserInfo().then((res) => {
    userInfo.value = res;
  });
});
</script>

<template>
  <div class="flex justify-center my-20">
    <van-image :src="userInfo.avatar" round class="h-70 w-70" />
  </div>
  <van-cell-group inset>
    <van-cell title="用户名" :value="userInfo.username" size="large" />
    <van-cell title="昵称" :value="userInfo.nickname" size="large" />
    <van-cell title="邮箱" :value="userInfo.email" size="large" />
    <van-cell title="电话" :value="userInfo.phoneNumber" size="large" />
    <van-cell size="large">
      <template #title>
        <div class="flex space-x-20">
          <van-tag
            color="#7232dd"
            size="large"
            v-for="r in userInfo.roles"
            :key="r.roleId"
          >
            {{ r.name }}
          </van-tag>
        </div>
      </template>
    </van-cell>
  </van-cell-group>
</template>

<style lang="less" scoped></style>

<route lang="json5">
{
  name: "ProfileEdit",
  meta: {
    title: "个人信息",
  },
}
</route>
