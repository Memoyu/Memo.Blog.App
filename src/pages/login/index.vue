<script setup lang="ts">
import { useRouter } from "vue-router";
import type { RouteMap } from "vue-router";
import { useRouteCacheStore, useUserStore } from "@/stores";

import logo from "~/images/logo.png";
import { PageEnum } from "@/common/enums";

const router = useRouter();
const userStore = useUserStore();
const routeCacheStore = useRouteCacheStore();

const loading = ref(false);

const postData = reactive({
  username: "",
  password: "",
});

const rules = reactive({
  username: [{ required: true, message: "请输入用户名" }],
  password: [{ required: true, message: "请输入密码" }],
});

onMounted(() => {
  routeCacheStore.clear();
});

async function login(values: any) {
  try {
    loading.value = true;
    await userStore.login({ ...postData, ...values });
    const { redirect, ...othersQuery } = router.currentRoute.value.query;

    router.push({
      name: (redirect as keyof RouteMap) || PageEnum.HOME_NAME,
      query: {
        ...othersQuery,
      },
    });
  } finally {
    loading.value = false;
  }
}
</script>

<template>
  <div>
    <div class="mb-42 mt-30">
      <van-image :src="logo" class="h-120 w-full" alt="brand logo" />
    </div>
    <div class="m-x-a text-center w-7xl">
      <van-form
        :model="postData"
        :rules="rules"
        validate-trigger="onSubmit"
        @submit="login"
      >
        <div class="rounded-3xl overflow-hidden">
          <van-field
            v-model="postData.username"
            :rules="rules.username"
            name="username"
            placeholder="用户名"
          />
        </div>

        <div class="mt-16 rounded-3xl overflow-hidden">
          <van-field
            v-model="postData.password"
            type="password"
            :rules="rules.password"
            name="password"
            placeholder="密码"
          />
        </div>

        <div class="mt-16">
          <van-button
            :loading="loading"
            type="primary"
            native-type="submit"
            round
            block
          >
            {{ "登录" }}
          </van-button>
        </div>
      </van-form>
    </div>
  </div>
</template>

<route lang="json5">
{
  name: "Login",
  meta: {
    title: "登录",
  },
}
</route>
