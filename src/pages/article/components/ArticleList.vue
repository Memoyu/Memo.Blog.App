<script setup lang="ts">
import dayjs from "dayjs";
import { Article } from "@/types/interfaces/article";

const articles = ref<Article[]>([
  {
    articleId: "8716065430175749",
    title:
      "博客站点维护20240508博客站点维护20240508博客站点维护20240508博客站点维护20240508",
    banner: "http://oss.blog.memoyu.com/articles/banner/-99992b03364.png",
    comments: 6,
    views: 96,
    likes: 0,
    updateDateTime: new Date("2025-07-31 19:23:35"),
  },
  {
    articleId: "8715972916150277",
    title: "个人博客站点，启动！",
    banner: "http://oss.blog.memoyu.com/articles/banner/-999947432de.png",
    comments: 3,
    views: 67,
    likes: 0,
    updateDateTime: new Date("2025-07-30 12:22:50"),
  },
  {
    articleId: "9252338862194693",
    title: "博客站点维护20240811",
    banner: "http://oss.blog.memoyu.com/articles/banner/-9999f113ea6.gif",
    comments: 0,
    views: 60,
    likes: 0,
    updateDateTime: new Date("2025-07-31 12:23:30"),
  },
]);
const loading = ref(false);
const finished = ref(true);

onMounted(() => {
  console.log("文章");
});
</script>

<template>
  <div class="article-summary">
    <van-grid :border="false" :column-num="3">
      <van-grid-item>
        <p class="summary-title">文章总数</p>
        <p class="summary-num">120</p>
      </van-grid-item>
      <van-grid-item>
        <p class="summary-title">评论总数</p>
        <p class="summary-num">1320</p>
      </van-grid-item>
      <van-grid-item>
        <p class="summary-title">阅读量</p>
        <p class="summary-num">12022</p>
      </van-grid-item>
    </van-grid>
  </div>
  <div>
    <van-search placeholder="请输入搜索关键词" />
  </div>
  <div>
    <van-list v-model:loading="loading" :finished="finished">
      <van-cell v-for="item in articles" :key="item.articleId">
        <div class="flex">
          <div class="shrink-0">
            <van-image width="90" height="80" fit="cover" :src="item.banner" />
          </div>
          <div class="ml-30 flex flex-col w-full">
            <div class="shrink-0">
              <van-text-ellipsis
                :content="item.title"
                class="text-black text-left"
              />
            </div>

            <div class="mt-15 flex space-x-20">
              <div class="article-num-item">
                <div class="i-carbon:view" />
                <p>{{ item.views }}</p>
              </div>
              <div class="article-num-item">
                <div class="i-carbon:chat" />
                <p>{{ item.comments }}</p>
              </div>
              <div class="article-num-item">
                <div class="i-carbon:thumbs-up" />
                <p>{{ item.likes }}</p>
              </div>
            </div>
            <div class="article-num-item text-left">
              <div class="i-carbon:update-now" />
              <div>
                {{ dayjs(item.updateDateTime).format("YYYY-MM-DD HH:mm") }}
              </div>
            </div>
          </div>
        </div>
      </van-cell>
    </van-list>
  </div>
</template>
<style lang="less" scoped>
.article-summary {
  padding: 20px 10px;
  background-color: var(--van-cell-background);

  .summary-title {
    color: var(--van-gray-7);
  }
  .summary-num {
    font-size: 20px;
    line-height: 28px;
    font-weight: 700;
  }
}

.article-num-item {
  --at-apply: flex items-center space-x-5;
}
</style>
