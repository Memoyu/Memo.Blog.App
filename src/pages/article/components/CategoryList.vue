<script setup lang="ts">
import api from "@/services/api";
import { ArticleCategory } from "@/types/interfaces";

const searchName = ref("");
const categories = ref<ArticleCategory[]>([]);

onMounted(() => {
  // 获取分类列表
  api.articleCategories(searchName.value).then((res) => {
    categories.value = res;
  });
});
</script>

<template>
  <div>
    <van-search placeholder="请输入搜索关键词" />
  </div>
  <van-list>
    <list-card v-for="item in categories" :key="item.categoryId">
      <div class="h-40 flex justify-between items-center text-black text-left">
        <div class="flex items-center w-3/4">
          <div class="w-2/4">{{ item.name }}</div>
          <div class="flex items-center space-x-7">
            <!-- <div class="i-carbon:property-relationship" /> -->
            <p>{{ item.articles }}</p>
          </div>
        </div>

        <div class="category-edit">
          <div class="i-carbon:edit" />
        </div>
      </div>
    </list-card>
  </van-list>
</template>
<style lang="less" scoped>
.category-edit {
  padding: 8px;
  border-radius: 50px;
  background-color: var(--van-background);
}
</style>
