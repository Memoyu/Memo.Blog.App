<script setup lang="ts">
import api from "@/services/api";
import { Note } from "@/types/interfaces";
import { useScrollParent, useEventListener } from "@vant/use";
import { debounce } from "lodash";
import router from "@/router";
import { dateFormat } from "@/utils/date";

const route = useRoute();
const query = ref(route.query as { id: string });
const note = ref<Note>();
const expandMinWidth = 30;
const expandMaxWidth = 120;
const menuExpand = ref<boolean>(true);

const menuBoxRef = ref();
const previewBoxRef = ref();
const scrollParent = useScrollParent(previewBoxRef);
const oldScrollTop = ref(0);

const content = ref("");

const showOutline = ref(false);

useEventListener("scroll", previewScroll, {
  target: scrollParent,
  passive: true,
});

onMounted(() => {
  menuBoxRef.value.style.width = `${expandMaxWidth}px`;

  // 获取笔记详情
  api.noteGet(query.value.id).then((res) => {
    note.value = res;
    content.value = res.content;
  });
});

function previewScroll() {
  let scrollTop =
    window.pageYOffset ||
    document.documentElement.scrollTop ||
    document.body.scrollTop;
  // 滚动条滚动的距离
  let scrollStep = scrollTop - oldScrollTop.value;
  // 更新——滚动前，滚动条距文档顶部的距离
  oldScrollTop.value = scrollTop;
  if (scrollStep < 0) {
    // console.log("滚动条向上滚动了！");
    changeMenuExpand(true);
  } else {
    // console.log("滚动条向下滚动了！");
    changeMenuExpand(false);
  }
}

function onMenuLeftClick() {
  changeMenuExpand(true);
}

// 防抖调整宽度
const changeMenuExpand = debounce(function (expand: boolean) {
  // console.log(expand);
  menuExpand.value = expand;
  if (!menuBoxRef.value) return;
  if (expand) {
    menuBoxRef.value.style.width = `${expandMaxWidth}px`;
  } else {
    menuBoxRef.value.style.width = `${expandMinWidth}px`;
  }
}, 50);

function onNoteEditClick() {
  // console.log("编辑笔记");
  router.push({ name: "NoteEdit", query: { id: note.value?.noteId } });
}

function onOutlineClick() {
  // console.log("笔记分组");
  showOutline.value = true;
}
</script>

<template>
  <nav-bar :title="note?.title">
    <template #right>
      <van-icon class="i-carbon-list" />
    </template>
  </nav-bar>
  <div>
    <div class="menu-container">
      <div class="menu-box" ref="menuBoxRef">
        <div v-if="!menuExpand" class="menu-left" @click="onMenuLeftClick">
          <van-icon name="arrow-left" class="menu-left-icon" />
        </div>
        <div v-else class="menu-list">
          <div class="menu-list-item" @click="onNoteEditClick">
            <van-icon name="edit" class="menu-list-icon" />
            <div class="menu-list-text">编辑</div>
          </div>
          <div class="menu-list-item" @click="onOutlineClick">
            <van-icon name="list-switch" class="menu-list-icon" />
            <div class="menu-list-text">大纲</div>
          </div>
        </div>
      </div>
    </div>
    <div ref="previewBoxRef">
      <div class="preview-header">
        <div class="preview-title">{{ note?.title }}</div>
        <div class="preview-author">
          <div>{{ note?.author.nickname }}</div>
          <div>{{ note?.group.title }}</div>
          <div>
            {{ dateFormat(note?.updateTime) }}
          </div>
        </div>
      </div>
      <div class="preview-content">
        <md-preview :content="content" v-model:show-outline="showOutline" />
      </div>
    </div>
  </div>
</template>

<style lang="less" scoped>
.menu-container {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
}
.menu-box {
  z-index: 99;
  height: 60px;
  overflow: hidden;
  background: var(--van-background-2);
  border-radius: 30px 0px 0px 30px;
  --at-apply: absolute bottom-60 right-0 flex justify-center items-center;
  transition: all 0.3s;
}
.menu-left {
  height: 100%;
  display: flex;
  align-items: center;
}
.menu-left-icon {
  font-size: 20px;
  margin-left: 5px;
  color: var(--van-text-color-2);
}

.menu-list {
  --at-apply: flex items-center;
}
.menu-list-item {
  padding: 0 13px;
}
.menu-list-text {
  font-size: 12px;
  color: var(--van-text-color-2);
}
.menu-list-icon {
  font-size: 23px;
}

.preview-header {
}
.preview-title {
  font-size: 1.75em;
  font-weight: 600;
  line-height: 1.25;
}

.preview-author {
  color: var(--van-text-color-2);
  --at-apply: flex items-center space-x-15 mt-9;
}

.preview-content {
  margin-top: 10px;
}
</style>

<route lang="json5">
{
  name: "NotePreview",
  meta: {
    title: "查看笔记",
  },
}
</route>
