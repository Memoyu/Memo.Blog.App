<script setup lang="ts">
import api from "@/services/api";
import { Note } from "@/types/interfaces";
import { closeToast, showLoadingToast } from "vant";

const route = useRoute();
const query = ref(route.query as { id: string; groupId: string });

const noteTitlRef = ref();

const loadEditor = ref<boolean>(true);

const note = ref<Note>();
const id = ref(query.value.id);
const groupId = ref(query.value.groupId);
const title = ref("");
const content = ref("");
const showOutline = ref(false);

onMounted(() => {
  showLoadingToast({
    duration: 10,
    forbidClick: true,
    message: "加载中...",
  });
  // 传入id则获取详情
  if (id.value) {
    // 获取笔记详情
    api.noteGet(query.value.id).then((res) => {
      title.value = res.title;
      content.value = res.content;

      // 标题栏获取焦点，使其重算高度
      nextTick(() => noteTitlRef.value.focus());
    });
  }
});

watch(
  () => loadEditor,
  (loading) => {
    if (!loading) closeToast();
  },
);
</script>

<template>
  <nav-bar :show-title="false">
    <template #right>
      <div class="i-carbon-list" @click="showOutline = !showOutline" />
    </template>
  </nav-bar>
  <div class="note-container">
    <div class="note-title">
      <van-field
        ref="noteTitlRef"
        v-model="title"
        rows="1"
        autosize
        type="textarea"
        placeholder="请输入标题"
      />
    </div>
    <md-editor
      v-model:loading="loadEditor"
      v-model:content="content"
      v-model:show-outline="showOutline"
    />
  </div>
</template>

<style lang="less" scoped>
.note-container {
  height: calc(100vh - 170px);
  overflow-y: auto;
}

.note-title {
  :deep(.van-cell) {
    background: var(--van-background);
    font-size: 1.75em;
    font-weight: 600;
    line-height: 1.25;
    padding: 0;
  }
  :deep(.van-cell::after) {
    border: none;
  }

  --at-apply: mb-18;
}
</style>

<route lang="json5">
{
  name: "NoteEdit",
  meta: {
    title: "编辑笔记",
  },
}
</route>
