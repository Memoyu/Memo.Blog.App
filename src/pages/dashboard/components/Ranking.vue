<script setup lang="ts">
import api from "@/services/api";
import { ArticleRankingItem } from "@/types/interfaces/article";

const ranking = ref<ArticleRankingItem[]>();
const loading = ref(false);
const finished = ref(true);

onMounted(() => {
  api.articleRanking(10).then((res) => {
    ranking.value = res;
  });
});
</script>

<template>
  <div class="mt-7">
    <p class="ranking-tilte">文章排行</p>
    <van-list v-model:loading="loading" :finished="finished">
      <van-cell v-for="item in ranking" :key="item.articleId">
        <div class="flex">
          <div class="shrink-0 flex items-center">
            <van-image width="140" height="80" :src="item.banner" />
          </div>
          <div class="ml-30 flex flex-col justify-between">
            <div>
              <van-text-ellipsis :content="item.title" class="text-black" />
            </div>
            <div class="flex space-x-20">
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
          </div>
        </div>
      </van-cell>
    </van-list>
  </div>
</template>

<style lang="less" scoped>
.ranking-tilte {
  font-size: var(--van-line-height-md);
  font-weight: 700;
}

.article-num-item {
  --at-apply: flex items-center space-x-5;
}
</style>
