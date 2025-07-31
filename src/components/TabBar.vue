<script setup lang="ts">
import { routeWhiteList } from "@/common/configs/routes";

const active = ref(0);
const route = useRoute();

const show = computed(() => route.name && routeWhiteList.includes(route.name));
</script>

<template>
  <van-tabbar v-if="show" v-model="active" route placeholder>
    <van-tabbar-item replace to="/">
      <template #icon>
        <div class="i-carbon:grid" />
      </template>
    </van-tabbar-item>
    <van-tabbar-item replace to="/article">
      <template #icon>
        <div class="i-carbon:blog" />
      </template>
    </van-tabbar-item>
    <van-tabbar-item replace to="/moment">
      <template #icon>
        <div class="i-carbon:layers" />
      </template>
    </van-tabbar-item>
    <van-tabbar-item replace to="/profile">
      <template #icon>
        <div class="i-carbon:user" />
      </template>
    </van-tabbar-item>
  </van-tabbar>
</template>
