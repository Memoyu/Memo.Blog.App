import { Note, NoteUpdateTitleRequest } from "@/types/interfaces";
import Request from "@/utils/request";

export default {
  catalogList() {
    return Request.get<any>("note/list/catalog");
  },

  noteGet(id: string) {
    return Request.get<Note>("note/get", { params: { noteId: id } });
  },

  titleUpdate(req: NoteUpdateTitleRequest) {
    return Request.put<string>("note/update/title", req);
  },
};
