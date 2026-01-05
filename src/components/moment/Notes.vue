<script setup lang="ts">
import dayjs from "dayjs";

const loading = ref(false);
const finished = ref(true);

const search = ref("");
const page = ref(1);
const pageSize = 15;
const catalogs = ref<any>({
  "": [
    {
      type: "catalog",
      id: "1",
      title: "C#",
    },
    {
      type: "catalog",
      id: "2",
      title: "软考",
    },
    {
      type: "catalog",
      id: "3",
      title: "计算基础",
    },
    {
      type: "note",
      id: "4",
      title: "如何提升自己",
    },
  ],
  "1": [
    {
      type: "catalog",
      id: "11",
      title: "WPF",
    },
    {
      type: "note",
      id: "12",
      title: "如何学习C#",
    },
    {
      type: "note",
      id: "13",
      title: "C#进阶",
    },
  ],
  "11": [
    {
      type: "note",
      id: "111",
      title: "WPF宝典",
    },
    {
      type: "catalog",
      id: "112",
      title: "WPF Demo",
    },
  ],
});
const selectCatalog = ref("");
const breadcrumbs = ref([
  {
    id: "1",
    title: "C#",
  },
  {
    id: "2",
    title: "软考dadad",
  },
  {
    id: "3",
    title: "软考dawdawd",
  },
  {
    id: "4",
    title: "软考dawda",
  },
  {
    id: "5",
    title: "软考ffawfaf",
  },
  {
    id: "6",
    title: "软考gagafawf",
  },
  {
    id: "7",
    title: "软考gagaggag",
  },
  {
    id: "8",
    title: "软考agagawg",
  },
]);

onMounted(() => {});

function getNodeIcon(type: string) {
  return type === "catalog"
    ? "i-carbon:folder"
    : "i-carbon:align-box-middle-center";
}

function getNodeIconColor(type: string) {
  return type === "catalog" ? "rgb(214, 150, 97)" : "#969799";
}

function onCatalogNodeClick(id: string) {
  selectCatalog.value = id;
}
</script>

<template>
  <div class="flex items-center m-10">
    <van-icon name="arrow-left" size="25" />
    <div class="breadcrumb-item mr-12">Root</div>
    <div class="flex items-center overflow-x-auto">
      <div class="flex" v-for="(item, index) in breadcrumbs">
        <div class="breadcrumb-item whitespace-nowrap">{{ item.title }}</div>
        <div class="mx-6" v-if="index < breadcrumbs.length - 1">/</div>
      </div>
    </div>
  </div>
  <van-list v-model:loading="loading" :finished="finished">
    <list-card
      class="user-item"
      v-for="item in catalogs[selectCatalog] ?? []"
      :key="item.id"
    >
      <div
        class="flex items-center space-x-30"
        @click="() => onCatalogNodeClick(item.id)"
      >
        <van-icon
          :class="getNodeIcon(item.type)"
          :color="getNodeIconColor(item.type)"
        />
        <div>{{ item.title }}</div>
      </div>
    </list-card>
  </van-list>
</template>

<style lang="less" scoped>
.breadcrumb-item {
  color: var(--van-primary-color);
}
</style>
