<script setup lang="ts">
const active = ref(0);
</script>
<template>
  <nav-bar />
  <van-tabs v-model:active="active" sticky offset-top="46">
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
