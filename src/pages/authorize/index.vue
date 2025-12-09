<script setup lang="ts">
import Role from "./components/Role.vue";
import Permission from "./components/Permission.vue";

const active = ref(0);
</script>
<template>
  <van-tabs v-model:active="active" sticky>
    <van-tab title="角色">
      <role />
    </van-tab>
    <van-tab title="权限">
      <permission />
    </van-tab>
  </van-tabs>
</template>

<style lang="less" scoped></style>

<route lang="json5">
{
  name: "Authorize",
  meta: {
    title: "权限&角色",
  },
}
</route>
