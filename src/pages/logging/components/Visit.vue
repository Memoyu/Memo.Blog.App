<script setup lang="ts">
import { VisitLogPageItem } from "@/types/interfaces";

const logs = ref<VisitLogPageItem[]>([]);

onMounted(() => {});
</script>

<template>
  <van-list>
    <list-card class="visit-log-item" v-for="item in logs" :key="item.visitId">
      <div></div>
    </list-card>
  </van-list>
</template>

<style lang="less" scoped>
.visit-log-item {
}
</style>
