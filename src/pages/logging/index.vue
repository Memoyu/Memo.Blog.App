<script setup lang="ts">
const active = ref(0);
</script>

<template>
  <nav-bar />
  <van-tabs v-model:active="active" sticky offset-top="46">
    <van-tab title="系统">
      <system />
    </van-tab>
    <van-tab title="访客">
      <visit />
    </van-tab>
  </van-tabs>
</template>

<style lang="less" scoped></style>

<route lang="json5">
{
  name: "Logging",
  meta: {
    title: "日志",
  },
}
</route>
