<script setup lang="ts">
defineOptions({
  name: "Daily",
});

const active = ref(0);
const gap = ref({ x: 30, y: 80 });

const noteRef = ref();
const timelineRef = ref();

function onAddClick() {
  if (active.value === 0) {
    // 新增笔记
    noteRef.value.addClick();
  } else {
    // 新增动态
    timelineRef.value.addClick();
  }
}
</script>
<template>
  <van-tabs v-model:active="active" sticky>
    <van-tab title="笔记">
      <notes ref="noteRef" />
    </van-tab>
    <van-tab title="动态">
      <timeline ref="timelineRef" />
    </van-tab>
  </van-tabs>
  <van-floating-bubble :gap="gap" icon="plus" @click="onAddClick" />
</template>

<route lang="json5">
{
  name: "Daily",
  meta: {
    title: "日常",
    keepAlive: true,
  },
}
</route>
