<script setup lang="ts">
import { ArticleRankingItem } from "@/types/interfaces/article";

const ranking = ref<ArticleRankingItem[]>([
  {
    articleId: "8716065430175749",
    title: "博客站点维护20240508",
    banner: "http://oss.blog.memoyu.com/articles/banner/-99992b03364.png",
    comments: 6,
    views: 96,
    likes: 0,
  },
  {
    articleId: "8715972916150277",
    title: "个人博客站点，启动！",
    banner: "http://oss.blog.memoyu.com/articles/banner/-999947432de.png",
    comments: 3,
    views: 67,
    likes: 0,
  },
  {
    articleId: "9252338862194693",
    title: "博客站点维护20240811",
    banner: "http://oss.blog.memoyu.com/articles/banner/-9999f113ea6.gif",
    comments: 0,
    views: 60,
    likes: 0,
  },
]);
const loading = ref(false);
const finished = ref(false);
</script>

<template>
  <p class="ranking-tilte">文章排行</p>
  <van-list v-model:loading="loading" :finished="finished">
    <van-cell v-for="item in ranking" :key="item.articleId">
      <div class="flex w-full">
        <van-image width="140" height="60" :src="item.banner" />
        <div class="ml-30 flex flex-col justify-between">
          <div>{{ item.title }}</div>
          <div class="flex space-x-15">
            <p>{{ item.views }}</p>
            <p>{{ item.comments }}</p>
            <p>{{ item.likes }}</p>
          </div>
        </div>
      </div>
    </van-cell>
  </van-list>
</template>

<style lang="less" scoped>
.ranking-tilte {
  font-size: var(--van-line-height-md);
  font-weight: 700;
}
</style>
