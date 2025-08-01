<script setup lang="ts">
const categories = [
  {
    categoryId: "10107176496726021",
    name: "客户端开发",
    articles: 2,
  },
  {
    categoryId: "9242527653363717",
    name: "Rust笔记",
    articles: 3,
  },
  {
    categoryId: "9051641047547909",
    name: "杂谈",
    articles: 2,
  },
  {
    categoryId: "8749774816346117",
    name: "企业微信",
    articles: 7,
  },
  {
    categoryId: "8712401030610949",
    name: "DevOps",
    articles: 2,
  },
  {
    categoryId: "8712399874686981",
    name: "运维",
    articles: 1,
  },
  {
    categoryId: "8712398759133189",
    name: "后端开发",
    articles: 1,
  },
  {
    categoryId: "8712398425227269",
    name: "博客站点",
    articles: 8,
  },
  {
    categoryId: "8712397694631941",
    name: "前端开发",
    articles: 1,
  },
  {
    categoryId: "1",
    name: "未分类",
    articles: 0,
  },
];

onMounted(() => {
  console.log("分类");
});
</script>

<template>
  <van-list>
    <van-cell v-for="item in categories" :key="item.categoryId">
      <div class="flex items-center text-black text-left">
        <div class="flex items-center">
          <div class="w-2/4">{{ item.name }}</div>
          <div class="flex items-center space-x-7">
            <i class="i-carbon:property-relationship" />
            <p>{{ item.articles }}</p>
          </div>
        </div>
        <i class="i-carbon:edit" :style="{ float: 'right' }" />
      </div>
    </van-cell>
  </van-list>
</template>
<style lang="less" scoped></style>
