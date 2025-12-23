<script setup lang="ts">
import ArticleList from "./components/ArticleList.vue";
import CategoryList from "./components/CategoryList.vue";
import TagList from "./components/TagList.vue";

const active = ref(0);
</script>
<template>
  <van-tabs v-model:active="active" swipeable sticky offset-top="46">
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
