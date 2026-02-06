<script setup lang="ts">
import Vditor from "vditor";
import "vditor/dist/index.css";

const vditor = ref();
const outlineRef = ref<Element>();

const content = defineModel<string>("content");
const showOutline = defineModel<boolean>("showOutline");
const loading = defineModel<boolean>("loading");

defineExpose({
  getContent,
});

const theme = computed(() => {
  return isDark.value ? "dark" : "classic";
});

const mode = computed(() => {
  return isDark.value ? "dark" : "light";
});

onMounted(() => {
  // console.log("editor");
  loading.value = true;
  const vr = new Vditor("vditor-editor", {
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
    ],
    after() {
      vr.setValue(content.value ?? "");
      vr.setTheme(theme.value, mode.value, "github");
      vditor.value = vr;
      loading.value = false;
      //console.log("render after");
    },
  });
});

watch(
  () => content.value,
  (newValue) => {
    if (!vditor.value) return;
    vditor.value.setValue(newValue ?? "");
  },
);

function onOutlineOpened() {
  var outlineElem = outlineRef.value as HTMLDivElement;
  const vr = vditor.value.vditor;
  // console.log(vditor, vditor[vditor.currentMode].element);
  Vditor.outlineRender(vr[vr.currentMode].element, outlineElem, vr);
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

function getContent() {
  if (!vditor.value) return "";
  return vditor.value.getValue();
}
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
        <div class="vditor-outline" ref="outlineRef"></div>
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

:deep(.vditor-toolbar__item) {
  padding: 0 6px;
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
