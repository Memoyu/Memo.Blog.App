<script setup lang="ts">
import Vditor from "vditor";
import "vditor/dist/index.css";

const editorRef = ref();
const outlineRef = ref<Element>();

const content = defineModel<string>("content");
const showOutline = defineModel<boolean>("showOutline");
const loading = defineModel<boolean>("loading");

const theme = computed(() => {
  return isDark.value ? "dark" : "classic";
});

const mode = computed(() => {
  return isDark.value ? "dark" : "light";
});

onMounted(() => {
  console.log("editor");
  loading.value = true;
  const vditor = new Vditor("vditor-editor", {
    placeholder: "请输入正文",
    toolbarConfig: {
      pin: true,
    },
    mode: "ir",
    cache: {
      enable: false,
    },
    toolbar: [
      "headings",
      "bold",
      "italic",
      "strike",
      "line",
      "quote",
      "list",
      "ordered-list",
      "check",
      "indent",
      "outdent",
      {
        name: "table",
        suffix: "",
        prefix: "",
      },
      "code",
      "inline-code",
      "link",
      {
        hotkey: "⇧⌘I",
        name: "image",
        tipPosition: "n",
        tip: "添加图片",
        className: "",
        icon: '<svg><use xlink:href="#icon-image"></use></svg>',
      },
      "undo",
      "redo",
      "fullscreen",
    ],
    after() {
      vditor.setValue(content.value ?? "");
      vditor.setTheme(theme.value, mode.value, "github");
      editorRef.value = vditor;
      loading.value = false;
    },
  });
});

watch(
  () => content.value,
  (newValue) => {
    if (loading.value) return;
    editorRef.value.setValue(newValue);
    loading.value = false;
  },
);

function onOutlineOpened() {
  const editorElem = document.querySelector(".vditor-ir")
    ?.firstElementChild as HTMLDivElement;
  var outlineElem = outlineRef.value as HTMLDivElement;

  Vditor.outlineRender(editorElem, outlineElem);
  if (outlineElem.innerText.trim() !== "") {
    outlineElem.style.display = "block";
    initOutline(outlineElem);
  }
}

const initOutline = (outlineElem: HTMLElement) => {
  outlineElem.firstElementChild!.addEventListener("click", (event: Event) => {
    let target = event.target as HTMLElement;
    if (!target.classList.contains("vditor-outline__action")) {
      // console.log("点击节点");
      showOutline.value = false;
    }
  });
};
</script>

<template>
  <div>
    <div class="vditor-editor-container">
      <div id="vditor-editor"></div>
    </div>
    <van-popup
      v-model:show="showOutline"
      round
      position="bottom"
      :style="{ height: '40%' }"
      @opened="onOutlineOpened"
    >
      <div class="vditor-outline-container">
        <div class="vditor-outline-title">大纲</div>
        <div ref="outlineRef" />
      </div>
    </van-popup>
  </div>
</template>

<style lang="less" scoped>
:deep(.vditor-toolbar) {
  position: fixed;
  bottom: 0;
  left: 0;
  right: 0;
  top: unset;
}

:deep(.vditor-outline__action) {
  height: 14px;
  width: 14px;
}

:deep(.vditor) {
  border: none;
}

:deep(.vditor-reset) {
  background-color: transparent !important;
  padding: 0 !important;
}

.vditor-editor-container {
}

.vditor-outline-container {
  margin: 10px 0;
}

.vditor-outline-title {
  font-size: var(--van-font-size-lg);
  --at-apply: flex justify-center font-bold;
}
</style>
