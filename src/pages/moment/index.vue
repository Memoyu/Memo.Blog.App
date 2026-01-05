<script setup lang="ts">
const active = ref(0);
const gap = ref({ x: 30, y: 80 });

function onAddClick() {
  if (active.value === 0) {
    // 新增笔记
  } else {
    // 新增动态
  }
}
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
  <van-floating-bubble :gap="gap" icon="plus" @click="onAddClick" />
</template>

<route lang="json5">
{
  name: "Moment",
  meta: {
    title: "动态",
  },
}
</route>
