<script setup lang="ts">
const active = ref(0);
</script>
<template>
  <van-tabs v-model:active="active" swipeable sticky>
    <van-tab title="全部">
      <article-list />
    </van-tab>
    <van-tab title="分类">
      <category-list />
    </van-tab>
    <van-tab title="标签">
      <tag-list />
    </van-tab>
  </van-tabs>
</template>

<route lang="json5">
{
  name: "Article",
  meta: {
    title: "文章",
  },
}
</route>
