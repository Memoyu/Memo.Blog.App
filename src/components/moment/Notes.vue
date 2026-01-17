<script setup lang="ts">
import api from "@/services/api";
import { NoteCatalogItem } from "@/types/interfaces";
import router from "@/router";

type HistoryCatalog = {
  id: string;
  title: string;
};

const loading = ref(false);
const finished = ref(true);

const showCatalogSet = ref(false);

const search = ref("");
const catalogs = ref<any>({});
const currentCatalog = ref("");
const historyCatalog = ref<HistoryCatalog[]>([]);

onMounted(() => {
  // 获取笔记目录列表
  api.catalogList().then((res) => {
    catalogs.value = res;
  });
});

function isCatalog(type: number) {
  return type === 0;
}

function getNodeIcon(type: number) {
  return isCatalog(type)
    ? "i-carbon-folder"
    : "i-carbon-align-box-middle-center";
}

function getNodeIconColor(type: number) {
  return isCatalog(type) ? "rgb(214, 150, 97)" : "#969799";
}

function onBackClick() {
  if (historyCatalog.value.length < 1) {
    return;
  }

  // 移除最后一个历史记录
  historyCatalog.value.pop();
  const last = historyCatalog.value[historyCatalog.value.length - 1];
  const id = last?.id ?? "";
  currentCatalog.value = id;
}

function onRootClick() {
  currentCatalog.value = "";
  // 清空历史记录
  historyCatalog.value = [];
}

function onHistoryCatalogClick(index: number, item: HistoryCatalog) {
  currentCatalog.value = item.id;
  // 截取历史记录
  historyCatalog.value = historyCatalog.value.slice(0, index + 1);
}

function onNoteCatalogClick(item: NoteCatalogItem) {
  if (!isCatalog(item.type)) {
    // 是笔记时，跳转笔记页面
    router.push({ name: "NotePreview", query: { id: item.id } });
    return;
  }
  currentCatalog.value = item.id;
  historyCatalog.value.push({
    id: item.id,
    title: item.title,
  });
}

function onNoteCatalogSetClick(e: MouseEvent, item: NoteCatalogItem) {
  e.stopPropagation();
  showCatalogSet.value = true;
}
</script>

<template>
  <div class="flex items-center my-15">
    <van-icon name="arrow-left" size="25" class="pr-8" @click="onBackClick" />
    <div class="breadcrumb-item mr-12" @click="onRootClick">Root</div>
    <div class="breadcrumb-box flex items-center overflow-scroll">
      <div class="flex" v-for="(item, index) in historyCatalog">
        <div
          class="breadcrumb-item whitespace-nowrap"
          @click="() => onHistoryCatalogClick(index, item)"
        >
          {{ item.title }}
        </div>
        <div class="mx-6" v-if="index < historyCatalog.length - 1">/</div>
      </div>
    </div>
  </div>
  <van-list v-model:loading="loading" :finished="finished">
    <list-card v-for="item in catalogs[currentCatalog] ?? []" :key="item.id">
      <div class="catalog-box" @click="() => onNoteCatalogClick(item)">
        <div class="flex items-center">
          <!-- <div class="i-carbon-folder" /> -->
          <div
            :size="19"
            :class="getNodeIcon(item.type)"
            :style="{ color: getNodeIconColor(item.type) }"
          />
          <van-text-ellipsis class="ml-8" :content="item.title" />
        </div>
        <div v-if="isCatalog(item.type)" class="flex items-center">
          <div class="catalog-count">
            {{ item.count }}
          </div>
          <div @click="(e) => onNoteCatalogSetClick(e, item)">
            <van-icon name="ellipsis" size="25" />
          </div>
        </div>
      </div>
    </list-card>
  </van-list>

  <van-popup v-model:show="showCatalogSet" round position="bottom">
    <div style="text-align: center; padding: 15px; height: 200px">
      <p>固定高度</p>
    </div>
  </van-popup>
</template>

<style lang="less" scoped>
.breadcrumb-item {
  color: var(--van-primary-color);
}
.catalog-box {
  --at-apply: flex justify-between items-center py-5;
}
.catalog-count {
  margin-right: 20px;
  display: flex;
  align-items: center;
  justify-content: center;
  width: 25px;
  height: 25px;
  border-radius: 50%;
  background-color: var(--van-background-2);
}
</style>
