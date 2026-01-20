import {
  Note,
  NoteUpdateTitleRequest,
  NoteUpdateGroupRequest,
  NoteUpdateRequest,
  NoteCatalogRequest,
  CreateNoteGroupRequest,
  CreateNoteRequest,
} from "@/types/interfaces";
import Request from "@/utils/request";

export default {
  createGroup(req: CreateNoteGroupRequest) {
    return Request.post<string>("note/create/group", req);
  },

  createNote(req: CreateNoteRequest) {
    return Request.post<string>("note/create", req);
  },
  noteUpdate(req: NoteUpdateRequest) {
    return Request.put<string>("note/update", req);
  },

  titleUpdate(req: NoteUpdateTitleRequest) {
    return Request.put<string>("note/update/title", req);
  },

  groupUpdate(req: NoteUpdateGroupRequest) {
    return Request.put<string>("note/update/group", req);
  },

  catalogList(onlyGroup?: boolean) {
    return Request.get<any>("note/list/catalog", {
      params: { onlyGroup } as NoteCatalogRequest,
    });
  },

  noteGet(id: string) {
    return Request.get<Note>("note/get", { params: { noteId: id } });
  },
};
