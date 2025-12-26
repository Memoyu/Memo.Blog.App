<script setup lang="ts">
const active = ref(0);
</script>
<template>
  <van-tabs v-model:active="active" sticky>
    <van-tab title="笔记">
      <notes />
    </van-tab>
    <van-tab title="动态">
      <timeline />
    </van-tab>
  </van-tabs>
</template>

<route lang="json5">
{
  name: "Moment",
  meta: {
    title: "动态",
  },
}
</route>
