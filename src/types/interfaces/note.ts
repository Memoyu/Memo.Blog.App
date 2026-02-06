export interface NoteCatalogRequest {
  onlyGroup?: boolean;
}

export interface NoteCatalogItem {
  type: number; // 分组类型 group: 0, note: 1
  id: string; // 分组id
  title: string; // 分组标题
  count: string; // 分组下项数量
}

export interface NoteAuthor {
  userId: string;
  nickname: string;
  avatar: string;
}

export interface NoteGroup {
  groupId: string;
  title: string;
}

export interface Note {
  noteId: string; // 笔记id
  title: string; // 笔记标题
  content: string; // 笔记内容
  group: NoteGroup; // 笔记分组
  author: NoteAuthor; // 笔记作者
  createTime: Date;
  updateTime?: Date;
}

export interface NoteUpdateTitleRequest {
  Id: string;
  type: number;
  title: string;
}

export interface NoteUpdateGroupRequest {
  Id: string;
  type: number;
  groupId?: string;
}

export interface NoteUpdateRequest {
  noteId: string; // 笔记id
  groupId?: string; // 笔记分组Id
  title: string; // 笔记标题
  content: string; // 笔记内容
}

export interface CreateNoteGroupRequest {
  parentId?: string;
  title: string;
}

export interface CreateNoteRequest {
  groupId?: string;
  title: string; // 笔记标题
  content?: string; // 笔记内容
}
