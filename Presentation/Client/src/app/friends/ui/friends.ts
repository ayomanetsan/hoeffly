export interface FriendResponse {
  id: string;
  name: string;
  email: string;
  status: InvitationStatus;
  isSender: boolean;
}

export enum InvitationStatus {
  Pending = 0,
  Accepted = 1,
  Rejected = 2,
}

export interface SendFriendshipRequest {
  email: string;
}

export interface ManageFriendshipRequest {
  friendshipId: string;
  status: InvitationStatus;
}
