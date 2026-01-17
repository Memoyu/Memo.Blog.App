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
      <list-card
        class="ranking-item"
        v-for="item in ranking"
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
                <div class="i-carbon-view" />
                <p>{{ item.views }}</p>
              </div>
              <div class="art-info-item">
                <div class="i-carbon-chat" />
                <p>{{ item.comments }}</p>
              </div>
              <div class="art-info-item">
                <div class="i-carbon-thumbs-up" />
                <p>{{ item.likes }}</p>
              </div>
            </div>
          </div>
        </div>
      </list-card>
    </van-list>
  </div>
</template>

<style lang="less" scoped>
.ranking-item {
  background: var(--van-background-2);
}

.ranking-tilte {
  font-size: var(--van-line-height-md);
  font-weight: 700;
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
</style>
