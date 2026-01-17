<script setup lang="ts">
import Vditor from "vditor";
import "vditor/dist/index.css";

const editorRef = ref();
const outlineRef = ref<Element>();

const content = defineModel<string>("content", { default: "" });
const showOutline = defineModel<boolean>("showOutline");

const theme = computed(() => {
  return isDark.value ? "dark" : "classic";
});

const mode = computed(() => {
  return isDark.value ? "dark" : "light";
});

onMounted(() => {
  editorRef.value = new Vditor("vditor-editor", {
    toolbarConfig: {
      pin: true,
    },
    mode: "ir",
    cache: {
      enable: false,
    },
    height: window.innerHeight - 160,
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
        icon: '<svg><use xlink:href="#vditor-icon-image"></use></svg>',
      },
      "undo",
      "redo",
      "fullscreen",
    ],
    after() {
      editorRef.value.setValue(content.value);
      editorRef.value.setTheme(theme.value, mode.value, "github");
    },
  });
});

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
      <div id="vditor-editor" ref="editorRef"></div>
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
