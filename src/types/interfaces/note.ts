export interface NoteCatalogItem {
  type: number; // 目录类型 catalog: 0, note: 1
  id: string; // 目录id
  title: string; // 目录标题
  count: string; // 目录下项数量
}

export interface NoteAuthor {
  userId: string;
  nickname: string;
  avatar: string;
}

export interface NoteCatalog {
  catalogId: string;
  title: string;
}

export interface Note {
  noteId: string; // 笔记id
  title: string; // 笔记标题
  content: string; // 笔记内容
  catalog: NoteCatalog; // 笔记目录
  author: NoteAuthor; // 笔记作者
  createTime: Date;
  updateTime?: Date;
}
