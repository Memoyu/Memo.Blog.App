<script setup lang="ts">
const themeShow = ref(false);
</script>

<template>
  <van-cell-group inset>
    <van-cell is-link title="深色模式" size="large" @click="themeShow = true" />
  </van-cell-group>

  <theme v-model:show="themeShow" />
</template>

<style lang="less" scoped></style>

<route lang="json5">
{
  name: "Setting",
  meta: {
    title: "设置",
  },
}
</route>
