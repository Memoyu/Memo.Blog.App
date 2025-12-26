<script setup lang="ts">
import dayjs from "dayjs";
import api from "@/services/api";
import { ArticlePageItem, ArticleSummary } from "@/types/interfaces/article";

const summary = ref<ArticleSummary>();
const articles = ref<ArticlePageItem[]>([]);
const loading = ref(false);
const finished = ref(true);

const searchTitle = ref("");
const page = ref(1);
const pageSize = 15;

onMounted(() => {
  // 获取汇总数据
  api.articleSummary().then((res) => {
    summary.value = res;
  });
  // 获取文章列表
  api
    .articlePage({
      title: searchTitle.value,
      page: page.value,
      size: pageSize,
    })
    .then((res) => {
      articles.value = res.items;
    });
});
</script>

<template>
  <div class="art-summary-box">
    <van-grid :border="false" :column-num="3">
      <van-grid-item>
        <p class="summary-title">文章总数</p>
        <p class="summary-num">{{ summary?.articles }}</p>
      </van-grid-item>
      <van-grid-item>
        <p class="summary-title">评论总数</p>
        <p class="summary-num">{{ summary?.comments }}</p>
      </van-grid-item>
      <van-grid-item>
        <p class="summary-title">阅读量</p>
        <p class="summary-num">{{ summary?.views }}</p>
      </van-grid-item>
    </van-grid>
  </div>
  <div>
    <van-search placeholder="请输入搜索关键词" />
  </div>
  <div>
    <van-list v-model:loading="loading" :finished="finished">
      <list-card
        class="art-item"
        v-for="item in articles"
        :key="item.articleId"
      >
        <div class="flex">
          <div class="shrink-0 flex items-center">
            <van-image width="140" height="80" :src="item.banner" />
          </div>
          <div class="ml-15 flex flex-col justify-between">
            <div>
              <van-text-ellipsis :content="item.title" />
            </div>

            <div class="art-info-box art-gray-font">
              <div class="art-info-item">
                <div class="i-carbon:view" />
                <p>{{ item.views }}</p>
              </div>
              <div class="art-info-item">
                <div class="i-carbon:chat" />
                <p>{{ item.comments }}</p>
              </div>
              <div class="art-info-item">
                <div class="i-carbon:thumbs-up" />
                <p>{{ item.likes }}</p>
              </div>
            </div>
            <div class="art-date-box art-gray-font">
              <div class="i-carbon:update-now" />
              <div>
                {{ dayjs(item.updateTime).format("YYYY-MM-DD HH:mm") }}
              </div>
            </div>
          </div>
        </div>
      </list-card>
    </van-list>
  </div>
</template>
<style lang="less" scoped>
.art-summary-box {
  padding: 20px 10px;
  background-color: var(--van-background-2);

  .summary-title {
    color: var(--van-gray-7);
  }
  .summary-num {
    font-size: 20px;
    line-height: 28px;
    font-weight: 700;
  }
}

.art-item {
  background: var(--van-background-2);
}

.art-gray-font {
  font-size: var(--van-font-size-md);
  color: var(--van-text-color-2);
}

.art-info-box {
  --at-apply: mt-15 flex space-x-20;
  .art-info-item {
    --at-apply: flex items-center space-x-5;
  }
}
.art-date-box {
  --at-apply: mt-5 flex items-center space-x-5;
}
</style>
