//
//  PaeDaeSharedDelegate.h
//
//  Created by Miguel Morales on 7/19/12.
//  Copyright (c) 2012 PaeDae Inc. All rights reserved.

#import <UIKit/UIKit.h>
#import "PaeDaeSDK.h"

@interface PaeDaeSharedDelegate : NSObject<PaeDaeInitDelegate, PaeDaeAdDelegate>
+ (id) sharedDelegate;
@end
