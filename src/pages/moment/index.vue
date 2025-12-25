<script setup lang="ts">
import Aggregation from "./components/Aggregation.vue";
import Timeline from "./components/Timeline.vue";

const active = ref(0);
</script>
<template>
  <van-tabs v-model:active="active" sticky>
    <van-tab title="动态">
      <timeline />
    </van-tab>
    <van-tab title="评论&赞">
      <aggregation />
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
